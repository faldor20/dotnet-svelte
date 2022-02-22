import { writable } from 'svelte/store';
import { Api } from './Api';

export const userId = writable(0);
export const api = new Api();