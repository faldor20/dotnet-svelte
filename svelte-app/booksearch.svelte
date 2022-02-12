<script lang="ts">

	import {Option,some,none} from "fp-ts/Option"
	import * as O from "fp-ts/Option"
	import * as API from"./Api" 
	import Book from "./book.svelte";

	let bookTitle:string;
	const api=new API.Api()
	let results:API.BookListing[]=[]
	function doSearch() {
		api.api.libraryGetBooksByTitle({title:bookTitle})
		.then( x=>results=x.data)
	}
	
</script>

<main>
	<h1>Book title search </h1>
    <input bind:value={bookTitle}/>
	<button on:click={doSearch}>Search</button>
	{#each results as book }
		<Book book={book}/>
	{/each}

</main>

<style>
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

	@media (min-width: 640px) {
		main {
			max-width: none;
		}
	}
</style>