<script lang="ts">
    import type { Book, BookListing } from "../Api";
    import { api } from "../stores";
    
    export let book:BookListing;
    export let loan:(bookId:number)=>void;
    let available=getAvailable(book.books);
    let canReserve=available.length>0;
    console.log("canReserve?",canReserve);

    function getAvailable(books:Book[]){
        console.log("books:",books);
        return books.filter((book )=>book.loanInfo==null);
    }

    let imagePath=api.baseUrl+"/api/Library/cover/"+book.id
</script>

<div class="card" >
    <img src={imagePath} alt="Book cover" >
    <div>
        <div>
            <span class="title">{book.title}</span>
            <span class="author"> by: {book.author}</span>
        </div>
        <p class="description">{book.description}</p>
    </div>
    <button class="loan" disabled={!canReserve} on:click={()=>{loan(available[0].id);console.log("hey")}}>Loan</button>
</div>

<style lang="postcss">
    
    .card{
        width: fit-content;
        @apply flex-shrink self-center h-40 flex flex-row shadow-xl rounded max-w-5xl;
    }
    .title{
        @apply font-bold text-xl ;
    }
    .author{
        @apply text-sm whitespace-nowrap ;
    }
    .description{
        @apply overflow-hidden overflow-ellipsis;
    }
    .card>img{
        @apply p-1;
    }
    
	button.loan{
        @apply self-center max-h-10 rounded-b shadow-sm;
    }
    button.loan:disabled{
        @apply bg-gray-600;
    }
</style>