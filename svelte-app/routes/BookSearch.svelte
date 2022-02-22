<script lang="ts">
	import * as API from"../Api" 
	import { userId } from "../stores";
	import Book from "../components/book.svelte";
	import { loop_guard } from "svelte/internal";

	let bookTitle:string;
	const api=new API.Api()
	let results:API.BookListing[]=[]
	function doSearch() {
		api.api.libraryGetBooksByTitle(bookTitle)
		.then( x=>results=x.data)
	}
	async function loanBook(listingId:number,bookId:number) {
		let lend=await api.api.libraryLendBook($userId,bookId);
		if (lend.ok) {
			console.log("loan res:",lend);
			let a= await api.api.libraryGetLoanInfo(bookId);
			if(a.ok){
				results.find(x=>x.id==listingId).books=a.data;
				console.log("Got new loaninfo")
			}
			else{
				console.error("Could not get new Listing Info")
			}
		}
		else {
			console.error("lending error: ",lend.statusText)
		}
		
		console.log("done Loaning");
		
	}
	
</script>

<main>
	<h1>Book title search </h1>
    <input bind:value={bookTitle}/>
	<button on:click={doSearch}>Search</button>
	<div class="bookList">

		{#each results as book }
		<Book book={book} loan={x=>loanBook(book.id,x)}/>
		{/each}
	</div>

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