using ITS.Domain.Models;
using Microsoft.JSInterop;

namespace ITS.Pages
{
    public partial class Departments
    {
        IEnumerable<Department> tableData = Enumerable.Empty<Department>();
        Department department = new();
        protected override async void OnInitialized()
        {
            await LoadData();
        }
        async Task LoadData()
        {
            tableData = await departmentService.GetAll();
            department = new();
            StateHasChanged();
        }
        void Edit(Department record)
        {
            department = record;

        }
        async Task Delete(int id)
        {
            var confirm = await javaScript.InvokeAsync<bool>("confirm", "Are you sure you want to delete this record?");
            if (!confirm)
            {
                return;
            }
            if (await departmentService.Delete(id))
            {
                await LoadData();
            }
            else
            {
                await javaScript.InvokeVoidAsync("alert", "An error occurred while trying to delete the department");
            }
        }
        async Task Save()
        {
            if (department.Id == 0)
            {

                if (await departmentService.Add(department))
                {

                    await LoadData();
                }
                else
                {
                    await javaScript.InvokeVoidAsync("alert", "An error occurred while trying to save the department");
                }
            }
            else
            {

                if (await departmentService.Update(department))
                {
                    await LoadData();
                }
                else
                {
                    await javaScript.InvokeVoidAsync("alert", "An error occurred while trying to save the department");
                }
            }
        }

    }
}
