const input = document.querySelector("input");
const body = document.querySelector("header");

const toggleThemeMode = () => {
    body.classList.toggle("dark");
};

input.onchange = toggleThemeMode;