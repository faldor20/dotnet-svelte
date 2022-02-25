<script lang="ts">
    import type { Book, BookListing } from "../Api";
    import { api } from "../stores";
    
    export let book:BookListing;
    

    let imagePath=api.baseUrl+"/api/Library/cover/"+book.id
</script>

<div class="card" >
    <img src={imagePath} alt="Book cover" >
    <div class="cardBody">
        <div >
            <span class="title">{book.title}</span>
            <span class="author"> by: {book.author}</span>
        </div>
        <p  class="description">{book.description}</p>
    </div>
    <slot class="float-right" name="end"></slot>
    
</div>

<style lang="postcss">
    .grid-auto-3{
        grid-template-columns: repeat(3,auto);
    }
    .cardBody{
        @apply h-24  overflow-ellipsis overflow-hidden line-clamp-3 md:max-h-full md:line-clamp-4;
        //max-height: 70%;
    }
    .card{
        
        width: fit-content;
        @apply overflow-ellipsis overflow-hidden self-center h-40   shadow-xl rounded md:max-w-5xl;
        @apply grid  grid-flow-row-dense  grid-cols-auto-2  md:grid-cols-auto-3;


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
        @apply p-1 max-h-full h-40;
        @apply md:w-auto row-span-2;
        object-fit:contain;
    }
    
	button.loan{
        @apply self-center max-h-10 rounded-b shadow-sm;
    }
    button.loan:disabled{
        @apply bg-gray-600;
    }
</style>