import { LoginState } from "./LoginState";

export interface LoginState {
  username: string;
  password: string;
};

export const LoginInitialState: LoginState = {
  username: '',
  password: ''
};