// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Octopus.Interfaces;

public interface IRegistration : IDisposable
{
    bool IsSuccessful { get; }
    int Id { get; }
}
