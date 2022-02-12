<script lang="ts">
    import type { Book, BookListing } from "../Api";


    export let book:BookListing;
    export let loan:(bookId:number)=>void;
    let available=getAvailable(book.books);
    let canReserve=available.length>0;
    console.log("canReserve?",canReserve);
    function getAvailable(books:Book[]){
        console.log("books:",books);
        return books.filter((book )=>book.loanInfo==null);
    }

</script>

<div>
    <h2>{book.title}</h2>
    <p><span class="font-extralight"> by:</span> {book.author}</p>
    <p>{book.description}</p>
    <button class="loan" disabled={!canReserve} on:click={()=>{loan(available[0].id);console.log("hey")}}>Loan</button>
</div>

<style lang="postcss">
    
	button.loan{
        @apply rounded-b shadow-sm;
    }
    button.loan:disabled{
        @apply bg-gray-600;
    }
</style>