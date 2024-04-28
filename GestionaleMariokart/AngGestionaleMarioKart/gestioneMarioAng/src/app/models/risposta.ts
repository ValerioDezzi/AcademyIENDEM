import { Giocatore } from "./giocatore";

export class Risposta {
    status: string | undefined;
    data?: string | Giocatore | Giocatore[] | undefined | null
}
