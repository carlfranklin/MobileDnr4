using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using MvvmHelpers;
using MvvmHelpers.Commands;
using DotNetRocks.Services;
using DotNetRocks.Models;
using DotNetRocks.Views;

namespace DotNetRocks.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private ApiService ApiService = new ApiService();
        public List<int> ShowNumbers { get; set; } = new List<int>();
        public int RecordsToRead { get; set; } = 20;
        public int LastShowNumber { get; set; }

        public HomePageViewModel()
        {
            var t = Task.Run(() => GetNextBatchOfShows());
            t.Wait();
        }

        public async Task GetNextBatchOfShows()
        {
            if (ShowNumbers.Count == 0)
            {
                ShowNumbers = await ApiService.GetShowNumbers();
                if (ShowNumbers == null || ShowNumbers.Count == 0) return;
                LastShowNumber = ShowNumbers.First<int>() + 1;
            }

            var request = new GetByShowNumbersRequest()
            {
                ShowName = "dotnetrocks",
                Indexes = (from x in ShowNumbers where x < LastShowNumber && x > (LastShowNumber - RecordsToRead) select x).ToList()
            };

            var nextBatch = await ApiService.GetByShowNumbers(request);
            if (nextBatch == null || nextBatch.Count == 0) return;

            AllShows.AddRange(nextBatch);
            LastShowNumber = nextBatch.Last<Show>().ShowNumber;
        }

        public async Task NavigateToDetailPage(int ShowNumber)
        {
            var route = $"{nameof(DetailPage)}?ShowNumber={ShowNumber}";
            await Shell.Current.GoToAsync(route);
        }

        private ICommand goToDetailsPage;
        public ICommand GoToDetailsPage
        {
            get
            {
                if (goToDetailsPage == null)
                {
                    goToDetailsPage = new AsyncCommand<int>(NavigateToDetailPage);
                }
                return goToDetailsPage;
            }
        }

        private ICommand loadMoreShows;
        public ICommand LoadMoreShows
        {
            get
            {
                if (loadMoreShows == null)
                {
                    loadMoreShows = new AsyncCommand(GetNextBatchOfShows);
                }
                return loadMoreShows;
            }
        }

        private List<Show> allShows = new List<Show>();
        public List<Show> AllShows
        {
            get => allShows;
            set => SetProperty(ref allShows, value);
        }

    }
}