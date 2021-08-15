import { JwtPayload } from "jwt-decode";

export class User {
  constructor(
    public userId: string,
    public isAdmin: boolean,
    public username: string) {}
}

export interface UserPayload extends JwtPayload {
  userId: string;
  isAdmin: boolean;
  name: string;
}
