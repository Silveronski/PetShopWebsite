document.addEventListener("DOMContentLoaded", () => {
    const categorySelection = document.getElementById("category-selection");   
    const tableRows = document.querySelectorAll(".catalog-table .animal-info");

    if (categorySelection) {
        categorySelection.selectedIndex = 0;

        categorySelection.addEventListener("change", () => {
            tableRows.forEach(row => {
                if (categorySelection.selectedIndex === 0 || parseInt(row.id) === categorySelection.selectedIndex) {
                    row.style.display = "table-row";
                }
                else {
                    row.style.display = "none";
                }
            });
        });
    }         
});