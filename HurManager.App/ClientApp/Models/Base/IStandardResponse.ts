export interface IStandardResponse<T> {
    Result: T;
    Message: string;
    Status: number;
    SystemMessage: string;
}