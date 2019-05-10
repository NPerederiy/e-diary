export interface ICardEditor{
    value: string;
    hasContent(): boolean;
    saveChanges(): void;
}