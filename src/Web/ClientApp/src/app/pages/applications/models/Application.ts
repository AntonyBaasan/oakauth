import { ApplicationType } from './ApplicationType';

export class Application {
  clientId: string;
  clientName: string;
  clientSecrets: string[];
  properties: {};
  description: string;
  applicationType: ApplicationType;
  allowedScopes: string[];
}
