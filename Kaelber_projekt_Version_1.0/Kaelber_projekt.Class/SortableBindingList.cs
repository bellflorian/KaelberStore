using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaelber_projekt.Class
{
    public class SortableBindingList<T> : BindingList<T>
    {
        public SortableBindingList(IEnumerable<T> collection) : base(new List<T>(collection)) { }

        private bool _isSorted;
        private ListSortDirection _sortDirection;
        private PropertyDescriptor _sortProperty;

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => _isSorted;

        protected override PropertyDescriptor SortPropertyCore => _sortProperty;
        protected override ListSortDirection SortDirectionCore => _sortDirection;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var items = Items as List<T>;
            if (items != null)
            {
                items.Sort((x, y) =>
                {
                    var xValue = prop.GetValue(x);
                    var yValue = prop.GetValue(y);
                    return direction == ListSortDirection.Ascending
                        ? Comparer<object>.Default.Compare(xValue, yValue)
                        : Comparer<object>.Default.Compare(yValue, xValue);
                });

                _isSorted = true;
                _sortDirection = direction;
                _sortProperty = prop;

                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
            else
            {
                _isSorted = false;
            }
        }

        protected override void RemoveSortCore()
        {
            _isSorted = false;
        }
    }
}
