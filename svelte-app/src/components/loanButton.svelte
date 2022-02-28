<script lang="ts">
    import { id } from "fp-ts/lib/Refinement";

    import type { Book, BookListing, User } from "../Api";

    import { api } from "../stores";

    export let listing: BookListing;
    export let userData: User;

    let available = getAvailable(listing.books ?? []);
    let canReserve = available.length > 0;
    console.log("canReserve?", canReserve);

    function getAvailable(books: Book[]) {
        console.log("books:", books);
        let alreadyHaveBook = userData.loanedBooks?.some(
            (x) => x.bookListingId == books[0]?.bookListingId
        );
        if (alreadyHaveBook) return [];
        else return books.filter((book) => book.loanInfo == null);
    }
    async function loanBook(userId: number, book: Book) {
        const bookId = book.id;
        canReserve = false;
        let lend = await api.api.libraryLendBook(userId, bookId);
        if (lend.ok) {
            console.log("loan res:", lend);
            let a = await api.api.libraryGetLoanInfo(bookId);
            if (a.ok) {
                listing.books = a.data;
                userData?.loanedBooks?.push(book);
                console.log("Got new loaninfo");
            } else {
                console.error("Could not get new Listing Info");
            }
        } else {
            canReserve=true;
            console.error("lending error: ", lend.statusText);
        }

        console.log("done Loaning");
    }
</script>

<button
    disabled={!canReserve}
    on:click={() => {
        loanBook(userData.id, available[0]);
        console.log("hey");
    }}
>
    Loan
</button>

<style>

	button{
        @apply self-center p-1 rounded-b shadow-sm grid;
        margin-left: auto;
        width: fit-content;
        height: fit-content;
    }
    button:disabled{
        @apply bg-gray-600;
    }
</style>
