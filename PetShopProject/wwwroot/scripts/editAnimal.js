document.addEventListener("DOMContentLoaded", () => {
    let categorySelection = document.getElementById("add-animal-selection");
    let selectedCategoryIndex = document.getElementById("selectedCategoryIndex");

    categorySelection.selectedIndex = selectedCategoryIndex.value - 1;

    window.updateSelectedIndex = function (select) {
        const selectedIndex = select.selectedIndex;
        selectedCategoryIndex.value = selectedIndex + 1;
    };
});