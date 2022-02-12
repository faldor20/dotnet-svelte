<script>
  import Router from 'svelte-spa-router'
  import routes from "./routes";
  import "./App.css";
</script>


  <header>
  <!-- 	<div class="corner">
      <a href="https://kit.svelte.dev">
      </a>
    </div> -->
    <ul>
    <li><a href="#/">Home</a></li>
    <li><a href="#/BookSearch">BookSearch</a></li>

</ul>


</header>

<main>
    <Router {routes}/>
    
    </main>
    
    <footer>
      <p>visit <a href="https://kit.svelte.dev">kit.svelte.dev</a> to learn SvelteKit</p>
    </footer>

<style>
    main{
        @apply object-fill max-h-full;
    }
    footer{
        @apply align-bottom;
    }
</style>
