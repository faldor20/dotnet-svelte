<script lang="ts">
	import type * as API from"../Api" 
	import type { BookListing } from "../Api";
    import { onMount } from "svelte";
	import { api,userData } from "../stores";
	import Book from "../components/book.svelte";
	import { loop_guard } from "svelte/internal";
    import { push } from "svelte-spa-router";
import { date } from "fp-ts";



    let thisUserData = ($userData ??push('/error/user')) as API.User;
    onMount(async () => {
        
    })
	function makeDate(date:API.NetDate) {
		return new Date(date.year,date.month-1,date.day)	
	}
	function daysBetween(first:Date,last:Date) {
		// To calculate the time difference of two dates
		var diff_Time = last.getTime() - first.getTime();
		
		// To calculate the no. of days between two dates
		var diff_Days = diff_Time / (1000 * 3600*24); 
		return diff_Days
	}
	
</script>

<main>
	<h1>Your books</h1>
    
	<div class="bookList">

		{#each (thisUserData?.loanedBooks??[]) as book }
		{#if book.loanInfo}
		<Book book={book.bookListing}>
			<svelte:fragment slot="end">
				{@const loanDate= makeDate(book.loanInfo.loanedDate)}
				{@const dueDate= makeDate(book.loanInfo.dueDate)} 
				<div class="flex flex-col">
					<span>Loaned: {loanDate.toLocaleDateString()}</span>
					<span>Due: {dueDate.toLocaleDateString()} </span>
					<span>{daysBetween(loanDate,dueDate)} days left</span>
				</div>
			</svelte:fragment>
		</Book>
		{:else} <span>book "{ book.bookListing?.title}", is loaned but does not have loanInfo</span>
		{/if}
		{/each}
		{#if (thisUserData?.loanedBooks??[]).length==0}
			<h2>Go loan out some books!</h2>
		{/if}
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