using System.Collections.Generic;

namespace NASA_Rover_Images.Utils
{
    public interface IPaginator
    {
        void SetItems(IReadOnlyList<object> items);

        void ClearItems();

        bool Next();

        bool Previous();

        IReadOnlyList<object> CurrentPageContent { get; }

        int TotalPages { get; }

        int CurrentPage { get; }

        int ItemsPerPage { get; }

        string PagingInfo { get; }
    }
}
