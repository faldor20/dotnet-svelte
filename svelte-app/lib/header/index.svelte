
<script lang="ts">
	import { Router, Link, Route } from "svelte-navigator";
	import Home from "$routes/Bome.svelte";
	import BookSearch from "$routes/BookSearch.svelte";

</script>


<header>
	<div class="corner">
		<a href="https://kit.svelte.dev">
		</a>
	</div>
	
	<nav>
		<Link to="/">Home</Link>
		<Link to="BookSearch">BookSearch</Link>
		
	</nav>

	<div class="corner">
		<!-- TODO put something else here? github link? -->
	</div>
</header>

<style>
	header {
		display: flex;
		justify-content: space-between;
	}
	.corner {
		width: 3em;
		height: 3em;
	}
	.corner a {
		display: flex;
		align-items: center;
		justify-content: center;
		width: 100%;
		height: 100%;
	}
	.corner img {
		width: 2em;
		height: 2em;
		object-fit: contain;
	}
	nav {
		display: flex;
		justify-content: center;
		--background: rgba(255, 255, 255, 0.7);
	}
	svg {
		width: 2em;
		height: 3em;
		display: block;
	}
	path {
		fill: var(--background);
	}
	ul {
		position: relative;
		padding: 0;
		margin: 0;
		height: 3em;
		display: flex;
		justify-content: center;
		align-items: center;
		list-style: none;
		background: var(--background);
		background-size: contain;
	}
	li {
		position: relative;
		height: 100%;
	}
	li.active::before {
		--size: 6px;
		content: '';
		width: 0;
		height: 0;
		position: absolute;
		top: 0;
		left: calc(50% - var(--size));
		border: var(--size) solid transparent;
		border-top: var(--size) solid var(--accent-color);
	}
	nav a {
		display: flex;
		height: 100%;
		align-items: center;
		padding: 0 1em;
		color: var(--heading-color);
		font-weight: 700;
		font-size: 0.8rem;
		text-transform: uppercase;
		letter-spacing: 0.1em;
		text-decoration: none;
		transition: color 0.2s linear;
	}
	a:hover {
		color: var(--accent-color);
	}
</style>