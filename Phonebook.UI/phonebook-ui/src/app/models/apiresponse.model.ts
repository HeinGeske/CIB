export interface ApiResonseMopdel<T>
{
    statusCode: number;
    message: string;
    result: T;
}