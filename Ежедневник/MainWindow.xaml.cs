using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;

namespace DailyPlanner
{
    public partial class MainWindow : Window
    {
        public class Note
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
        }

        public ObservableCollection<Note> Notes { get; set; }
        public DateTime SelectedDate { get; set; }
        public Note SelectedNote { get; set; }

        private string _filePath = "notes.json";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            SelectedDate = DateTime.Today;
            LoadData();
        }


        private void LoadData()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                Notes = JsonSerializer.Deserialize<ObservableCollection<Note>>(json);
            }
            else
            {
                Notes = new ObservableCollection<Note>();
            }
        }

        private void SaveData()
        {
            string json = JsonSerializer.Serialize(Notes);
            File.WriteAllText(_filePath, json);
        }

        private void AddNote()
        {
            var newNote = new Note { Date = SelectedDate };
            Notes.Add(newNote);
        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            AddNote(); // Вызываем метод добавления новой заметки
        }

        private void EditNote_Click(object sender, RoutedEventArgs e)
        {
            EditNote(); // Вызываем метод редактирования выбранной заметки
        }

        private void DeleteNote_Click(object sender, RoutedEventArgs e)
        {
            DeleteNote(); // Вызываем метод удаления выбранной заметки
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveData(); // Вызываем метод сохранения данных
        }

        private void EditNote()
        {
            // Редактирование выбранной заметки
        }

        private void DeleteNote()
        {
            if (SelectedNote != null)
            {
                Notes.Remove(SelectedNote);
            }
        }
    }
}
