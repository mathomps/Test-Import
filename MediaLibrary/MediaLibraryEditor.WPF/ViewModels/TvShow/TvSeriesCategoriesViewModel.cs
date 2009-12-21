using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MediaLibraryEditor.WPF.Models;
using System.Windows.Input;
using MediaLibraryEditor.WPF.Commands;

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
                             select cat.id;

            var catList = new List<TvSeriesCategoryViewModel>();

            foreach (var categ in categories)
            {
                catList.Add(new TvSeriesCategoryViewModel(categ));
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
            var newCategory = TvSeriesCategoryViewModel.NewCategory(_tvSeriesId);

            Categories.Add(newCategory);
            SelectedCategory = newCategory;
            OnPropertyChanged("Categories");
        }


        #endregion

        #region --  Properties --


        private List<TvSeriesCategoryViewModel> _categories;

        public List<TvSeriesCategoryViewModel> Categories
        {
            get { return _categories; }
            set
            {
                if (value == _categories) { return; }
                _categories = value;
                OnPropertyChanged("Categories");
            }
        }


        private TvSeriesCategoryViewModel _selectedCategory;

        public TvSeriesCategoryViewModel SelectedCategory
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

    public class TvSeriesCategoryViewModel : BusinessObjectBase
    {

        private MediaCatalogueEntities _ctx;
        private TV_SeriesCategory _category;

        #region --  Constructor  --

        public TvSeriesCategoryViewModel(Guid categoryId)
        {
            _ctx = new MediaCatalogueEntities();

            _category = (from cat in _ctx.TV_SeriesCategory
                            where cat.id == categoryId
                            select cat).FirstOrDefault();
            ID = _category.id;
            Title = _category.Title;
            Description = _category.Description;
            IsNew = false;
            IsDirty = false;

        }

        /// <summary>
        /// Constructor used by shared method to create a new empty TVSeriesCategory.
        /// </summary>
        private TvSeriesCategoryViewModel()
        {
            _ctx = new MediaCatalogueEntities();

            ID = Guid.NewGuid();
            Title = "New category";
            Description = "Enter a description for this category";
            IsNew = true;
            IsDirty = false;
        }

        #endregion

        #region --  ICommand  --


        private DelegateCommand _updateCommand;

        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new DelegateCommand(Update, CanUpdate);
                }
                return _updateCommand;
            }
        }

        private bool CanUpdate()
        {
            return IsDirty;
        }

        private void Update()
        {
        }




        #endregion

        #region --  Properties  --

        private Guid _id;

        public Guid ID
        {
            get { return _id; }
            private set
            {
                if (value == _id) { return; }
                _id = value;
                OnPropertyChanged("ID");
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (value == _title) { return; }
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) { return; }
                _description = value;
                OnPropertyChanged("Description");
            }
        }


        private Guid _seriesId;

        public Guid SeriesID
        {
            get { return _seriesId; }
            set
            {
                if (value == _seriesId) { return; }
                _seriesId = value;
                OnPropertyChanged("SeriesID");
            }
        }



        #endregion

        #region --  Methods  --

        public static TvSeriesCategoryViewModel NewCategory(Guid tvSeriesId)
        {
            var newCategory = new TvSeriesCategoryViewModel
                                   {
                                       SeriesID = tvSeriesId,
                                       IsDirty = false
                                   };
            return newCategory;
        }


        #endregion

    }


}
