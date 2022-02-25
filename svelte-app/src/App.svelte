<script lang="ts">
  import Router from "svelte-spa-router";
  import routes from "./routes";
import { userData } from "./stores";
</script>

<header>
  <!-- 	<div class="corner">
      <a href="https://kit.svelte.dev">
      </a>
    </div> -->
  <div class="nav">
    <a href="#/">Home</a>
    {#if ($userData!==null)}
    <a href="#/BookSearch">BookSearch</a>
    <a href="#/MyBooks">MyBooks</a>
    {:else}
    <span >BookSearch</span>
    <span >MyBooks</span>
    {/if}
  </div>
</header>

<main>
  <Router {routes} />
</main>

<footer>
  <p>
    visit <a href="https://kit.svelte.dev">kit.svelte.dev</a> to learn SvelteKit
  </p>
</footer>

<style global lang="postcss">
  * {
    box-sizing: border-box;
  }
  main {
    @apply object-fill max-h-full;
  }
  footer {
    @apply align-bottom;
  }

  .nav{

  }
  .nav * {
    @apply font-bold py-2 px-4 rounded  w-6;
  }
  .nav a {
    @apply bg-blue-500 text-white;
  }
  .nav span {
    @apply bg-gray-600 text-gray-100;
  }
  .nav a:hover {
      @apply bg-blue-700;
  }

</style>
