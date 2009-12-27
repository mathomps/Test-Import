using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using MediaLibraryEditor.WPF.Commands;
using MediaLibraryEditor.WPF.Models;

namespace MediaLibraryEditor.WPF.ViewModels.TvShow
{

    public class TvSeriesCategoriesViewModel : ViewModelBase
    {

        private Guid _tvSeriesId;

        public TvSeriesCategoriesViewModel(Guid tvSeriesId)
        {

            var ctx = new MediaCatalogueEntities();

            _tvSeriesId = tvSeriesId;

            var categories = from cat in ctx.TV_SeriesCategory
                                         .Include("TV_Series")
                             where cat.TV_Series.id == tvSeriesId
                             orderby cat.Title
                             select cat.id;

            var catList = new ObservableCollection<TvSeriesCategory>();

            foreach (var categ in categories)
            {
                catList.Add(new TvSeriesCategory(categ));
            }

            Categories = catList;

        }

        #region --  ICommand  --


        private DelegateCommand _addCategoryCommand;

        public ICommand AddCategoryCommand
        {
            get
            {
                if (_addCategoryCommand == null)
                {
                    _addCategoryCommand = new DelegateCommand(AddCategory, CanAddCategory);
                }
                return _addCategoryCommand;
            }
        }

        private bool CanAddCategory()
        {
            return true;
        }

        private void AddCategory()
        {
            var newCategory = TvSeriesCategory.NewCategory(_tvSeriesId);
            Categories.Add(newCategory);
            SelectedCategory = newCategory;
        }


        private DelegateCommand _deleteCategoryCommand;

        public ICommand DeleteCategoryCommand
        {
            get
            {
                if (_deleteCategoryCommand == null)
                {
                    _deleteCategoryCommand = new DelegateCommand(DeleteCategory, CanDeleteCategory);
                }
                return _deleteCategoryCommand;
            }
        }

        private bool CanDeleteCategory()
        {
            return SelectedCategory != null && SelectedCategory.DeleteCommand.CanExecute(null);
        }

        private void DeleteCategory()
        {
            SelectedCategory.DeleteCommand.Execute(null);
            Categories.Remove(SelectedCategory);
            SelectedCategory = null;
        }

        #endregion

        #region --  Properties --


        private ObservableCollection<TvSeriesCategory> _categories;

        public ObservableCollection<TvSeriesCategory> Categories
        {
            get { return _categories; }
            set
            {
                if (value == _categories) { return; }
                _categories = value;
                OnPropertyChanged("Categories");
            }
        }


        private TvSeriesCategory _selectedCategory;

        public TvSeriesCategory SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                if (value == _selectedCategory) { return; }
                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        #endregion

    }



}
