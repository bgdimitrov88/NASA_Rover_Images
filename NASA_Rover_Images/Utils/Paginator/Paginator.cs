using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NASA_Rover_Images.Utils
{
    public class Paginator : IPaginator, INotifyPropertyChanged
    {
        private IReadOnlyList<object> _items;
        private IReadOnlyList<object> _currentPageContent;
        private string _pagingInfo;
        private const string _pagingInfoFormat = "{0} of {1}";
        
        public Paginator(int itemsPerPage)
        {
            ItemsPerPage = itemsPerPage;
            _pagingInfo = string.Format(_pagingInfoFormat, 0, 0);
    }

        public void SetItems(IReadOnlyList<object> items)
        {
            if(items != null && items.Count > 0)
            {
                _items = items;

                TotalPages = _items.Count / ItemsPerPage;

                if(_items.Count % ItemsPerPage > 0)
                {
                    TotalPages++;
                }

                Update(1);
            }
            else
            {
                ClearItems();
            }
        }

        public void ClearItems()
        {
            TotalPages = 0;
            Update(0);
        }

        public bool Next()
        {
            if(CurrentPage < TotalPages)
            {
                Update(CurrentPage+1);

                return true;
            }

            return false;
        }

        public bool Previous()
        {
            if(CurrentPage > 1)
            {
                Update(CurrentPage-1);

                return true;
            }

            return false;
        }

        public IReadOnlyList<object> CurrentPageContent
        {
            get { return _currentPageContent;  }
        }

        public int TotalPages { get; private set; }

        public int CurrentPage { get; private set; }

        public int ItemsPerPage { get; private set; }

        public string PagingInfo
        {
            get { return _pagingInfo; }
            private set
            {
                _pagingInfo = value;
                OnPropertyChanged("PagingInfo");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void Update(int currentPage)
        {
            CurrentPage = currentPage;
            PagingInfo = string.Format(_pagingInfoFormat, CurrentPage, TotalPages);
            if(currentPage > 0)
            {
                _currentPageContent = _items.Skip((CurrentPage - 1) * ItemsPerPage).Take(ItemsPerPage).ToList();
            }
        }
    }
}
