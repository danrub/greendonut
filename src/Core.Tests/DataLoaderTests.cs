using System;
using System.Threading.Tasks;
using Xunit;

namespace GreenDonut
{
    public class DataLoaderTests
    {
        #region Constructor

        [Fact(DisplayName = "Constructor: Should throw an argument null exception for fetch")]
        public void ConstructorFetchNull()
        {
            // arrange
            FetchDataDelegate<string, string> fetch = null;
            var options = new DataLoaderOptions<string>();

            // act
            Action verify = () => new DataLoader<string, string>(fetch,
                options);

            // assert
            Assert.Throws<ArgumentNullException>("fetch", verify);
        }

        [Fact(DisplayName = "Constructor: Should throw an argument null exception for options")]
        public void ConstructorOptionsNull()
        {
            // arrange
            FetchDataDelegate<string, string> fetch =
                async keys => await Task.FromResult(new Result<string>[0]);
            DataLoaderOptions<string> options = null;

            // act
            Action verify = () => new DataLoader<string, string>(fetch,
                options);

            // assert
            Assert.Throws<ArgumentNullException>("options", verify);
        }

        [Fact(DisplayName = "Constructor: Should not throw any exception")]
        public void ConstructorNoException()
        {
            // arrange
            FetchDataDelegate<string, string> fetch =
                async keys => await Task.FromResult(new Result<string>[0]);
            var options = new DataLoaderOptions<string>();

            // act
            Action verify = () => new DataLoader<string, string>(fetch,
                options);

            // assert
            Assert.Null(Record.Exception(verify));
        }

        #endregion

        #region Set

        [Fact(DisplayName = "Set: Should throw an argument null exception for key")]
        public void SetKeyNull()
        {
            // arrange
            FetchDataDelegate<string, string> fetch =
                async keys => await Task.FromResult(new Result<string>[0]);
            var options = new DataLoaderOptions<string>();
            var loader = new DataLoader<string, string>(fetch, options);
            string key = null;
            var value = Task.FromResult(Result<string>.Resolve("Foo"));

            // act
            Action verify = () => loader.Set(key, value);

            // assert
            Assert.Throws<ArgumentNullException>("key", verify);
        }

        [Fact(DisplayName = "Set: Should throw an argument null exception for value")]
        public void ConstructorValueNull()
        {
            // arrange
            FetchDataDelegate<string, string> fetch =
                async keys => await Task.FromResult(new Result<string>[0]);
            var options = new DataLoaderOptions<string>();
            var loader = new DataLoader<string, string>(fetch, options);
            var key = "Foo";
            Task<Result<string>> value = null;

            // act
            Action verify = () => loader.Set(key, value);

            // assert
            Assert.Throws<ArgumentNullException>("value", verify);
        }

        [Fact(DisplayName = "Set: Should not throw any exception")]
        public void SetNoException()
        {
            // arrange
            FetchDataDelegate<string, string> fetch =
                async keys => await Task.FromResult(new Result<string>[0]);
            var options = new DataLoaderOptions<string>();
            var loader = new DataLoader<string, string>(fetch, options);
            var key = "Foo";
            var value = Task.FromResult(Result<string>.Resolve("Bar"));

            // act
            Action verify = () => loader.Set(key, value);

            // assert
            Assert.Null(Record.Exception(verify));
        }

        #endregion
    }
}
