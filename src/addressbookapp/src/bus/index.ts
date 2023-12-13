import mitt from "mitt";

type Events = {
  showEntry: Number;
}

export const bus = mitt<Events>();;
