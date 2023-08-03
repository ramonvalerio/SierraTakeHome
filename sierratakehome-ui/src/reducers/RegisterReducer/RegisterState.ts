import { RegisterState } from "./RegisterState";

export interface RegisterState {
  username: string;
  password: string;
};

export const RegisterInitialState: RegisterState = {
  username: '',
  password: ''
};