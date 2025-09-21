namespace Practices.Problems
{
    public record SearchMovie(int Shop, int Movie);
    public record MovieEntity(int Shop, int Movie, int Price) : IComparable<MovieEntity>
    {
        public int CompareTo(MovieEntity other)
        {
            if (Price == other.Price)
            {
                if (Shop == other.Shop)
                {
                    return Movie - other.Movie;
                }

                return Shop - other.Shop;
            }

            return Price - other.Price;
        }
    }

    public class MovieRentingSystem
    {
        private readonly Dictionary<int, SortedSet<MovieEntity>> _sortedMovies;
        private readonly Dictionary<SearchMovie, MovieEntity> _allMovies;
        private readonly SortedSet<MovieEntity> _rentedMovies;

        private const int MaxCount = 5;

        public MovieRentingSystem(int n, int[][] entries)
        {
            _allMovies = new();
            _sortedMovies = new();
            _rentedMovies = new();

            foreach (var entry in entries)
            {
                var (shop, movie, price) = (entry[0], entry[1], entry[2]);
                var searchMovie = new SearchMovie(shop, movie);
                var movieEntity = new MovieEntity(shop, movie, price);

                _allMovies[searchMovie] = movieEntity;

                if (!_sortedMovies.ContainsKey(movie))
                {
                    _sortedMovies[movie] = new();
                }

                _sortedMovies[movie].Add(movieEntity);
            }
        }

        public IList<int> Search(int movie)
        {
            var result = new List<int>();
            if (!_sortedMovies.ContainsKey(movie))
            {
                return result;
            }

            for (int i = 0; i < Math.Min(MaxCount, _sortedMovies[movie].Count); i++)
            {
                result.Add(_sortedMovies[movie].ElementAt(i).Shop);
            }

            return result;
        }

        public void Rent(int shop, int movie)
        {
            var searchMovie = new SearchMovie(shop, movie);
            if (_allMovies.ContainsKey(searchMovie))
            {
                var movieEntity = _allMovies[searchMovie];

                _rentedMovies.Add(movieEntity);
                _sortedMovies[movie].Remove(movieEntity);
            }
        }

        public void Drop(int shop, int movie)
        {
            var searchMovie = new SearchMovie(shop, movie);
            if (_allMovies.ContainsKey(searchMovie))
            {
                var movieEntity = _allMovies[searchMovie];

                _rentedMovies.Remove(movieEntity);
                _sortedMovies[movie].Add(movieEntity);
            }
        }

        public IList<IList<int>> Report()
        {
            var result = new List<IList<int>>();

            for (int i = 0; i < Math.Min(MaxCount, _rentedMovies.Count); i++)
            {
                var rentedMovie = _rentedMovies.ElementAt(i);
                result.Add([rentedMovie.Shop, rentedMovie.Movie]);
            }

            return result;
        }
    }
}
