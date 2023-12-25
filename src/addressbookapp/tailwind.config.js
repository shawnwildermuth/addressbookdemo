/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./src/**/*.{vue,ts,js}"
  ],
  theme: {
    extend: {
      fontFamily: {
        'sans': ['Noto Sans', 'sans-serif']
      }
    },
  },
  plugins: [require("daisyui")],
  daisyui: {
    themes: ["forest"],
  }
}

