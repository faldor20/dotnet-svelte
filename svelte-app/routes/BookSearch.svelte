<script lang="ts">
	import * as API from"../Api" 
	import { userId } from "../stores";
	import Book from "../components/book.svelte";
import { loop_guard } from "svelte/internal";

	let bookTitle:string;
	const api=new API.Api()
	let results:API.BookListing[]=[]
	function doSearch() {
		api.api.libraryGetBooksByTitle({title:bookTitle})
		.then( x=>results=x.data)
	}
	function loanBook(bookId:number) {
		api.api.libraryLendBook($userId,bookId).then(x=>console.log("loan res:",x)).catch(x=>console.log("loan res:",x));
		console.log("done Loaning");
		
	}
	
</script>

<main>
	<h1>Book title search </h1>
    <input bind:value={bookTitle}/>
	<button on:click={doSearch}>Search</button>
	{#each results as book }
		<Book book={book} loan={loanBook}/>
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