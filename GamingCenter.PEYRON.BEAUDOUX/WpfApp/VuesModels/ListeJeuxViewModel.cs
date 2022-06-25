using BusinessLayer;
using ClassLibrary.Entity;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.VuesModels
{
    public class ListeJeuxViewModel : INotifyPropertyChanged
    {
        public ListeJeuxViewModel()
        {
            manager = Manager.GetInstance();
            _listeJeux = new ObservableCollection<Jeu>(manager.GetAllJeux());
            _listeEvaluations = new ObservableCollection<Evaluation>(manager.GetAllEvaluations());
            ListeJeuxDisplay = new ObservableCollection<Jeu>(_listeJeux);
            ListeGenres = new ObservableCollection<Genre>(manager.GetAllGenres());
            ClearFilterCommand = new DelegateCommand(OnClearFilter);
            EditJeuCommand = new DelegateCommand(OnEdit);
            //SelectedJeu = ListeJeuxDisplay.First();         
        }



        #region --- INotifyPropertyChanged ---
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion

        #region --- fields ---
        private ObservableCollection<Jeu> _listeJeux;
        private ObservableCollection<Evaluation> _listeEvaluations;
        private ObservableCollection<Jeu> _listeJeuxDisplay;
        private ObservableCollection<Evaluation> _listeEvaluationsDisplay;
        private ObservableCollection<Genre> _listeGenres;
        private Jeu _selectedJeu;
        private Genre _selectedGenre;
        private DelegateCommand _clearFilterCommand;
        private DelegateCommand _editJeuCommand;
        private Manager manager;
        #endregion

        #region --- properties ---

        public ObservableCollection<Jeu> ListeJeuxDisplay
        {
            get
            {
                return _listeJeuxDisplay;
            }
            set
            {
                _listeJeuxDisplay = value;
                OnPropertyChanged("ListeJeuxDisplay");
            }
        }

        public ObservableCollection<Evaluation> ListeEvaluationsDisplay
        {
            get
            {
                return _listeEvaluationsDisplay;
            }
            set
            {
                _listeEvaluationsDisplay = value;
                OnPropertyChanged("ListeEvaluationsDisplay");
            }
        }

        public ObservableCollection<Genre> ListeGenres
        {
            get
            {
                return _listeGenres;
            }
            set
            {
                _listeGenres = value;
                OnPropertyChanged("ListeGenres");
            }
        }

        public Jeu SelectedJeu
        {
            get
            {
                return _selectedJeu;
            }
            set
            {
                _selectedJeu = value;
                ListeEvaluationsDisplay = new ObservableCollection<Evaluation>(_listeEvaluations.Where(eval => eval.JeuId == _selectedJeu.Id).ToList());
                OnPropertyChanged("SelectedJeu");
            }
        }

        public Genre SelectedGenre
        {
            get
            {
                return _selectedGenre;
            }
            set
            {
                _selectedGenre = value;
                _listeJeux.Count();
                ListeJeuxDisplay = new ObservableCollection<Jeu>(_listeJeux.Where(jeu => jeu.GenreId == _selectedGenre.Id).ToList());
                OnPropertyChanged("Genre");
            }
        }

        public DelegateCommand ClearFilterCommand
        {
            get
            {
                return _clearFilterCommand;
            }
            set
            {
                _clearFilterCommand = value;
                OnPropertyChanged("ClearFilterCommand");
            }
        }

        public DelegateCommand EditJeuCommand
        {
            get
            {
                return _editJeuCommand;
            }
            set
            {
                _editJeuCommand = value;
                OnPropertyChanged("EditJeuCommand");
            }
        }
        #endregion

        #region --- private methods ---
        private void OnClearFilter()
        {
            ListeJeuxDisplay.Clear();
            ListeJeuxDisplay = _listeJeux;
        }

        private void OnEdit()
        {
            manager.UpdateJeu(SelectedJeu);
        }
        #endregion
    }
}
