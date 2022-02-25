<script lang="ts">
	import { params } from "svelte-spa-router";
	const error = $params?.error;
</script>

<main>
	<h1>Oops spmethig went wrong.</h1>
    {#if error=="user"}
    <p>Somehow the user wasn't set, please set the user.</p>
    {:else if error==null}
    <p>no error has been sent, this is most likely becuase data has been lost due to a page reload. Persitent data is not yet supported.</p>
    {:else}
    <p>Got unsupported error "{error}"</p>

    {/if}

    <p>Return home:</p>
    <a href="#/Home">

</main>

<style>
	.bookList{
		@apply flex content-center justify-center;
	}
	main {
		text-align: center;
		padding: 1em;
		max-width: 240px;
		margin: 0 auto;
	}

	h1 {
		color: #ff3e00;
		text-transform: uppercase;
		font-size: 4em;
		font-weight: 100;
	}
	button{
		@apply px-2 m-2 border-2 border-gray-600 rounded shadow-sm;
	}
	input{
		@apply border-2 border-gray-600;
	}

	@media (min-width: 640px) {
		main {
			max-width: none;
		}
	}
</style>