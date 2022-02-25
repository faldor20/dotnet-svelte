import sveltePreprocess from "svelte-preprocess";
import autoprefixer from "autoprefixer";
import talwindcss from "tailwindcss";

export default {
  // Consult https://github.com/sveltejs/svelte-preprocess
  // for more information about preprocessors
  preprocess: [
    sveltePreprocess({
      postcss: true,
    }),
  ],
};
