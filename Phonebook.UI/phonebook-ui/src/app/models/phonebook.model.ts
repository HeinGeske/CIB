import { EntryModel } from './entry.model';

export interface PhonebookModel
{
    id:number;
    name:string;
    entries:EntryModel[];
}