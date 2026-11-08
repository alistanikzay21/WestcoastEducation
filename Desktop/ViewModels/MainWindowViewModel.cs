using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop.Models;

namespace Desktop.ViewModels;

public partial class MainViewModel : ViewModelBase
{

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsCoursesVisible))]
    [NotifyPropertyChangedFor(nameof(IsStudentsVisible))]
    [NotifyPropertyChangedFor(nameof(IsTeachersVisible))]
    public partial string CurrentPage { get; set; } = "Kurser";

    public bool IsCoursesVisible => CurrentPage == "Kurser";
    public bool IsStudentsVisible => CurrentPage == "Studenter";
    public bool IsTeachersVisible => CurrentPage == "Lärare";

    [ObservableProperty]
    public partial string StatusMessage { get; set; } = "";

    [RelayCommand]
    public void ShowCourses()
    {
        CurrentPage = "Kurser";
        StatusMessage = "";
    }

    [RelayCommand]
    public void ShowStudents()
    {
        CurrentPage = "Studenter";
        StatusMessage = "";
    }

    [RelayCommand]
    public void ShowTeachers()
    {
        CurrentPage = "Lärare";
        StatusMessage = "";
    }

    [ObservableProperty]
    public partial ObservableCollection<Course> Courses { get; set; } = [];

    [ObservableProperty]
    public partial string CourseNumberInput { get; set; } = "";

    [ObservableProperty]
    public partial string TitleInput { get; set; } = "";

    [ObservableProperty]
    public partial string LengthInput { get; set; } = "";

    [ObservableProperty]
    public partial string LengthUnitInput { get; set; } = "";

    [ObservableProperty]
    public partial string CourseTypeInput { get; set; } = "";

    [ObservableProperty]
    public partial string StartDateInput { get; set; } = "";

    [ObservableProperty]
    public partial string EndDateInput { get; set; } = "";

    [RelayCommand]
    public async Task LoadCoursesAsync()
    {
        try
        {
            var courses = await App.RestDbService.GetAllAsync<Course>("courses");
            Courses = new ObservableCollection<Course>(courses);
            StatusMessage = $"Antal kurser: {Courses.Count}";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Fel vid hämtning av kurser: {ex.Message}";
        }
    }

    [RelayCommand]
    public async Task AddCourseAsync()
    {
        if (string.IsNullOrWhiteSpace(CourseNumberInput) ||
            string.IsNullOrWhiteSpace(TitleInput) ||
            string.IsNullOrWhiteSpace(LengthInput) ||
            string.IsNullOrWhiteSpace(LengthUnitInput) ||
            string.IsNullOrWhiteSpace(CourseTypeInput))
        {
            StatusMessage = "Fyll i alla obligatoriska fält.";
            return;
        }

        if (!double.TryParse(LengthInput, out double length) || length <= 0)
        {
            StatusMessage = "Ange en giltig kurslängd.";
            return;
        }

        if (!string.IsNullOrWhiteSpace(StartDateInput) &&
            !DateTime.TryParse(StartDateInput, out _))
        {
            StatusMessage = "Ange ett giltigt startdatum.";
            return;
        }

        if (!string.IsNullOrWhiteSpace(EndDateInput) &&
            !DateTime.TryParse(EndDateInput, out _))
        {
            StatusMessage = "Ange ett giltigt slutdatum.";
            return;
        }

        DateTime? startDate = string.IsNullOrWhiteSpace(StartDateInput)
            ? null
            : DateTime.Parse(StartDateInput);

        DateTime? endDate = string.IsNullOrWhiteSpace(EndDateInput)
            ? null
            : DateTime.Parse(EndDateInput);

        if (startDate.HasValue && endDate.HasValue && endDate < startDate)
        {
            StatusMessage = "Slutdatum kan inte vara före startdatum.";
            return;
        }

        try
        {
            var course = new Course
            {
                CourseNumber = CourseNumberInput,
                Title = TitleInput,
                Length = LengthInput,
                LengthUnit = LengthUnitInput,
                CourseType = CourseTypeInput,
                StartDate = startDate,
                EndDate = endDate
            };

            await App.RestDbService.AddAsync("courses", course);

            CourseNumberInput = "";
            TitleInput = "";
            LengthInput = "";
            LengthUnitInput = "Week";
            CourseTypeInput = "Classroom";
            StartDateInput = "";
            EndDateInput = "";

            await LoadCoursesAsync();
            StatusMessage = "Kursen har lagts till!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Fel vid tillägg av kurs: {ex.Message}";
        }
    }

    [RelayCommand]
    public async Task DeleteCourseAsync(Course? course)
    {
        if (course == null || string.IsNullOrWhiteSpace(course.Id))
        {
            StatusMessage = "Kunde inte hitta kursen.";
            return;
        }

        try
        {
            await App.RestDbService.DeleteAsync("courses", course.Id);
            await LoadCoursesAsync();
            StatusMessage = "Kursen har raderats!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Fel vid radering: {ex.Message}";
        }
    }

    [ObservableProperty]
    public partial ObservableCollection<Student> Students { get; set; } = [];

    [ObservableProperty]
    public partial string FirstNameInput { get; set; } = "";

    [ObservableProperty]
    public partial string LastNameInput { get; set; } = "";

    [ObservableProperty]
    public partial string PhoneNumberInput { get; set; } = "";

    [ObservableProperty]
    public partial string PersonalNumberInput { get; set; } = "";

    [ObservableProperty]
    public partial string AddressInput { get; set; } = "";

    [ObservableProperty]
    public partial string PostalCodeInput { get; set; } = "";

    [ObservableProperty]
    public partial string CityInput { get; set; } = "";

    [RelayCommand]
    public async Task LoadStudentsAsync()
    {
        try
        {
            var students = await App.RestDbService.GetAllAsync<Student>("students");
            Students = new ObservableCollection<Student>(students);
            StatusMessage = $"Antal studenter: {Students.Count}";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Fel vid hämtning av studenter: {ex.Message}";
        }
    }

    [RelayCommand]
    public async Task AddStudentAsync()
    {
        if (string.IsNullOrWhiteSpace(FirstNameInput) ||
            string.IsNullOrWhiteSpace(LastNameInput) ||
            string.IsNullOrWhiteSpace(PhoneNumberInput) ||
            string.IsNullOrWhiteSpace(PersonalNumberInput) ||
            string.IsNullOrWhiteSpace(AddressInput) ||
            string.IsNullOrWhiteSpace(PostalCodeInput) ||
            string.IsNullOrWhiteSpace(CityInput))
        {
            StatusMessage = "Fyll i alla studentuppgifter.";
            return;
        }

        try
        {
            var student = new Student
            {
                FirstName = FirstNameInput,
                LastName = LastNameInput,
                PhoneNumber = PhoneNumberInput,
                PersonalNumber = PersonalNumberInput,
                Address = AddressInput,
                PostalCode = PostalCodeInput,
                City = CityInput
            };

            await App.RestDbService.AddAsync("students", student);

            FirstNameInput = "";
            LastNameInput = "";
            PhoneNumberInput = "";
            PersonalNumberInput = "";
            AddressInput = "";
            PostalCodeInput = "";
            CityInput = "";

            await LoadStudentsAsync();
            StatusMessage = "Studenten har lagts till!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Fel vid tillägg av student: {ex.Message}";
        }
    }

    [ObservableProperty]
    public partial ObservableCollection<Teacher> Teachers { get; set; } = [];

    [ObservableProperty]
    public partial string TeacherFirstNameInput { get; set; } = "";

    [ObservableProperty]
    public partial string TeacherLastNameInput { get; set; } = "";

    [ObservableProperty]
    public partial string TeacherPhoneNumberInput { get; set; } = "";

    [ObservableProperty]
    public partial string TeacherPersonalNumberInput { get; set; } = "";

    [ObservableProperty]
    public partial string TeacherAddressInput { get; set; } = "";

    [ObservableProperty]
    public partial string TeacherPostalCodeInput { get; set; } = "";

    [ObservableProperty]
    public partial string TeacherCityInput { get; set; } = "";

    [ObservableProperty]
    public partial string KnowledgeAreaInput { get; set; } = "";

    [ObservableProperty]
    public partial Teacher? SelectedTeacher { get; set; }

    [RelayCommand]
    public async Task LoadTeachersAsync()
    {
        try
        {
            var teachers = await App.RestDbService.GetAllAsync<Teacher>("teachers");
            Teachers = new ObservableCollection<Teacher>(teachers);
            StatusMessage = $"Antal lärare: {Teachers.Count}";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Fel vid hämtning av lärare: {ex.Message}";
        }
    }

    [RelayCommand]
    public async Task AddTeacherAsync()
    {
        if (string.IsNullOrWhiteSpace(TeacherFirstNameInput) ||
            string.IsNullOrWhiteSpace(TeacherLastNameInput) ||
            string.IsNullOrWhiteSpace(TeacherPhoneNumberInput) ||
            string.IsNullOrWhiteSpace(TeacherPersonalNumberInput) ||
            string.IsNullOrWhiteSpace(TeacherAddressInput) ||
            string.IsNullOrWhiteSpace(TeacherPostalCodeInput) ||
            string.IsNullOrWhiteSpace(TeacherCityInput) ||
            string.IsNullOrWhiteSpace(KnowledgeAreaInput))
        {
            StatusMessage = "Fyll i alla läraruppgifter.";
            return;
        }

        try
        {
            var teacher = new Teacher
            {
                FirstName = TeacherFirstNameInput,
                LastName = TeacherLastNameInput,
                PhoneNumber = TeacherPhoneNumberInput,
                PersonalNumber = TeacherPersonalNumberInput,
                Address = TeacherAddressInput,
                PostalCode = TeacherPostalCodeInput,
                City = TeacherCityInput,
                KnowledgeArea = KnowledgeAreaInput
            };

            await App.RestDbService.AddAsync("teachers", teacher);

            TeacherFirstNameInput = "";
            TeacherLastNameInput = "";
            TeacherPhoneNumberInput = "";
            TeacherPersonalNumberInput = "";
            TeacherAddressInput = "";
            TeacherPostalCodeInput = "";
            TeacherCityInput = "";
            KnowledgeAreaInput = "";

            await LoadTeachersAsync();
            StatusMessage = "Läraren har lagts till!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Fel vid tillägg av lärare: {ex.Message}";
        }
    }

    [RelayCommand]
    public void SelectTeacher(Teacher? teacher)
    {
        SelectedTeacher = teacher;
        KnowledgeAreaInput = teacher?.KnowledgeArea ?? "";
        StatusMessage = teacher == null
            ? ""
            : $"Vald lärare: {teacher.FirstName} {teacher.LastName}";
    }

[RelayCommand]
public async Task ChangeTeacherKnowledgeAreaAsync()
{
    if (SelectedTeacher == null)
    {
        StatusMessage = "Välj en lärare först.";
        return;
    }

    if (string.IsNullOrWhiteSpace(SelectedTeacher.Id))
    {
        StatusMessage = "Lärarens ID saknas.";
        return;
    }

    if (string.IsNullOrWhiteSpace(KnowledgeAreaInput))
    {
        StatusMessage = "Ange ett kompetensområde.";
        return;
    }

    try
    {
        string teacherId = SelectedTeacher.Id;

        await App.RestDbService.PatchAsync(
            "teachers",
            teacherId,
            new
            {
                knowledgeArea = KnowledgeAreaInput
            }
        );

        await LoadTeachersAsync();

        SelectedTeacher = null;

        foreach (var teacher in Teachers)
        {
            if (teacher.Id == teacherId)
            {
                SelectedTeacher = teacher;
                break;
            }
        }

        StatusMessage = "Kompetensområdet har sparats!";
    }
    catch (Exception ex)
    {
        StatusMessage = $"Fel vid uppdatering: {ex.Message}";
    }
}

}