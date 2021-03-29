export interface IHttpService {
    baseUrl: string;
    post<T>(relativeUrl: string, data: any): Promise<T>;
    get<T>(relativeUrl: string): Promise<T>;
    delete<T>(relativeUrl: string, data?: any): Promise<T>;
    put<T>(relativeUrl: string, data: any): Promise<T>;
}
