
// Greet.svelte
<script lang="ts">
    import type { Book, BookListing } from "./Api";


    export let book:BookListing;
    let canReserve= countAvailable(book.books)>1

    function countAvailable(books:Book[]){
        return books.reduce((count,book)=> {if(book.loanInfo==null) return count+1;else return count;},0)
    }
</script>

<div>
    <h2>{book.title}</h2>
    <p>by:{book.author}</p>
    <p>{book.description}</p>
    <button class="loan" disabled={canReserve}></button>
</div>

<style lang="postcss">
	button.loan{
        @apply rounded-b shadow-sm;
    }
    button.loan:disabled{
        @apply bg-gray-600;
    }
</style>