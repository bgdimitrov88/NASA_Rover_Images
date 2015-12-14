using System.Collections.Generic;

namespace NASA_Rover_Images.Utils
{
    public interface IPaginator
    {
        void SetPhotos(IReadOnlyList<object> items);

        bool Next();

        bool Previous();

        IReadOnlyList<object> CurrentPageContent { get; }

        int TotalPages { get; }

        int CurrentPage { get; }

        int ItemsPerPage { get; }

        string PagingInfo { get; }
    }
}
