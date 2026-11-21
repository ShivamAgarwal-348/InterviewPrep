using System.Collections;
using System.Runtime;
using System.Runtime.CompilerServices;

// 1. Generations: watch a living object get promoted
var survivor = new object();
Console.WriteLine($"New object:          generation {GC.GetGeneration(survivor)}"); // 0
GC.Collect(); // forces a full collection: only ever do this in a demo
Console.WriteLine($"After 1 collection:  generation {GC.GetGeneration(survivor)}"); // 1
GC.Collect();
Console.WriteLine($"After 2 collections: generation {GC.GetGeneration(survivor)}"); // 2

// 2. Garbage really gets freed: a WeakReference watches an object without keeping it alive
WeakReference tracker = CreateGarbage();
Console.WriteLine($"\nGarbage alive before collection? {tracker.IsAlive}"); // True
GC.Collect();
Console.WriteLine($"Garbage alive after collection?  {tracker.IsAlive}");   // False

// 3. Boxing: ArrayList boxes every int; List<int> doesn't
long bytesBefore = GC.GetAllocatedBytesForCurrentThread();
var boxedNumbers = new ArrayList();
for (int number = 0; number < 100_000; number++)
{
    boxedNumbers.Add(number); // each int is copied into its own heap object (a box)
}
long bytesWithBoxing = GC.GetAllocatedBytesForCurrentThread() - bytesBefore;

bytesBefore = GC.GetAllocatedBytesForCurrentThread();
var unboxedNumbers = new List<int>();
for (int number = 0; number < 100_000; number++)
{
    unboxedNumbers.Add(number); // stored directly inside List<int>'s int[]
}
long bytesWithoutBoxing = GC.GetAllocatedBytesForCurrentThread() - bytesBefore;

Console.WriteLine($"\nArrayList (boxing):    {bytesWithBoxing:N0} bytes allocated");
Console.WriteLine($"List<int> (no boxing): {bytesWithoutBoxing:N0} bytes allocated");

// 4. The Large Object Heap: 85,000 bytes or more skips Gen0
var smallBuffer = new byte[84_000];
var largeBuffer = new byte[85_000];
Console.WriteLine($"\n84,000-byte array: generation {GC.GetGeneration(smallBuffer)}"); // 0
Console.WriteLine($"85,000-byte array: generation {GC.GetGeneration(largeBuffer)}"); // 2: it went straight to the LOH

// 5. Which GC mode is this app using?
Console.WriteLine($"\nServer GC: {GCSettings.IsServerGC}"); // False: a plain console app uses workstation GC

// Creates an object, keeps no reference to it, and returns only a weak "watcher"
[MethodImpl(MethodImplOptions.NoInlining)]
static WeakReference CreateGarbage()
{
    var temporaryBuffer = new byte[1_000];
    return new WeakReference(temporaryBuffer);
}