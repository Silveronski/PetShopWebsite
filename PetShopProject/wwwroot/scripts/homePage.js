document.addEventListener("DOMContentLoaded", () => {
    const table = document.querySelector(".animals-table");
    const animalRows = document.querySelectorAll(".animal-info");

    if (animalRows.length === 0) {
        table.style.height = "16vh";
    }
});
