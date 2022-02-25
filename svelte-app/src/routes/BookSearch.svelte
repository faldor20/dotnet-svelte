<script lang="ts">
	import * as API from"../Api" 
	import { userData } from "../stores";
	import Book from "../components/book.svelte";
	import { loop_guard } from "svelte/internal";
	import LoanButton from "../components/loanButton.svelte";
	import { push } from "svelte-spa-router";
	import type { User } from "../Api";

	let bookTitle:string;
	let thisuserData = ($userData??push('/error/user')) as User;
	const api=new API.Api()
	let listings:API.BookListing[]=[]
	function doSearch() {
		api.api.libraryGetBooksByTitle(bookTitle)
		.then( x=>listings=x.data)
	}
	
	
</script>

<main>
	<h1>Book title search </h1>
    <input bind:value={bookTitle}/>
	<button on:click={doSearch}>Search</button>
	<div class="bookList">
		{#each listings as listing }
		<Book book={listing} > 
			<svelte:fragment slot="end">
				<LoanButton listing={listing} userData={thisuserData}/>
			</svelte:fragment>
		</Book> 
			
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
		max-width: none;
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

	@media (max-width: 900px) {
		main {
			margin: 0 0;
			max-width: none;
		}
	}
</style>