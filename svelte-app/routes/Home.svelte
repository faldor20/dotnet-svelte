<script lang="ts">
	import { each, onMount } from "svelte/internal";
	import { Api } from "../Api";

	import { userId } from "../stores";
	export let name: string;
	let id = 0;
	let userIds: number[] = [];
	let api = new Api();
	onMount(async () => {
		api.api
			.libraryGetUserIds()
			.then((x) => {
				console.log("got ids", userIds);
				userIds = x.data;
			})
			.catch((x) => console.error("failed getting userId ", x));
	});
</script>

<main>
	<h1>Hello {name}!</h1>
	<select bind:value={id} name="users" id="users">
		{#each userIds as id}
			<option value={id}>{id.toString()}</option>
		{/each}
	</select>
	<button on:click={() => userId.set(id)}>SetId</button>
	<p>
		Visit the <a href="https://svelte.dev/tutorial">Svelte tutorial</a> to learn
		how to build Svelte apps.
	</p>
</main>

<style lang="postcss">
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
