module.exports = {
  content: ["./svelte/**/*.{js,svelte,ts}"],
  /*   future: {
    purgeLayersByDefault: true,
    removeDeprecatedGapUtilities: true,
  }, */
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {
      gridTemplateColumns: {
        // Simple 16 column grid
          'auto-2': 'repeat(2, auto)',
        'auto-3': 'repeat(3, auto)',
        'auto-4': 'repeat(4, auto)',

    
      }},
  },
  variants: {
    extend: {},
  },
  plugins: [require("@tailwindcss/line-clamp")],
};
