// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", () => {
    const acc = document.querySelector(".acc");

    acc.addEventListener("mouseenter", () => {
        acc.classList.add("hovered");
    });

    acc.addEventListener("mouseleave", () => {
        acc.classList.remove("hovered");
    });
});
