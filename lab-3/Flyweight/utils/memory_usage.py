from sys import getsizeof

def measure_memory_usage(obj, seen=None):
    if seen is None:
        seen = set()
    if id(obj) in seen:
        return 0
    seen.add(id(obj))

    size = getsizeof(obj)
    if isinstance(obj, dict):
        size += sum(measure_memory_usage(k, seen) + measure_memory_usage(v, seen) for k, v in obj.items())
    elif isinstance(obj, (list, tuple, set)):
        size += sum(measure_memory_usage(i, seen) for i in obj)
    elif hasattr(obj, '__dict__'):
        size += measure_memory_usage(obj.__dict__, seen)

    return size
