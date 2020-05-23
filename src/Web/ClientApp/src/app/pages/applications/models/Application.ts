import { ApplicationType } from './ApplicationType';

export class Application {
  clientId: string;
  clientName: string;
  clientSecrets: string[];
  properties: {};
  clientDescription: string;
  applicationType: ApplicationType;
  allowedScopes: string[];
}
