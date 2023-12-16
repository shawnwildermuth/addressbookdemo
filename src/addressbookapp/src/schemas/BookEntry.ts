import { object, string, nullable } from "zod";

export const entrySchema = object({
  firstName: string().min(1),
  lastName: string().min(1),
  email: string().email(),
  cellPhone: string().optional(),
  homePhone: string().optional(),
  workPhone: string().optional(),
});

//export type entrySchemaType 