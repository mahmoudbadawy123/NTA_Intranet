export interface IAppConfig {
    env: {
        name: string;
        type: number;
    };
    apiServer: {
        url: string;      
        usingInternalApi:boolean;  
    };
}

