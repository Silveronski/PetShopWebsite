document.addEventListener("DOMContentLoaded", () => {
    const categorySelection = document.getElementById("add-animal-selection");
    categorySelection.selectedIndex = -1;

    window.updateSelectedIndex = function (select) {
        const selectedIndex = select.selectedIndex;
        document.getElementById("selectedCategoryIndex").value = selectedIndex;
    };
});