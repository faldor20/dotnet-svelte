import { writable } from 'svelte/store';
import type { Writable } from 'svelte/store';
import { Api } from './Api';
import type { User } from './Api';
//export const userId: Writable<number | null> = writable(null);
export const userData: Writable<User | null> = writable(null);
export const api = new Api();